using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace CanCOMApplication
{
    internal class DBhandler
    {

        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        private string connectionString;
        public List<TestStep> TestSteps = new List<TestStep>();
        public List<CanDataFrame> canDataFrames = new List<CanDataFrame>();
        public List<CanDevice> canDevices = new List<CanDevice>();

        


        public DBhandler()
        {
            Initialize();
        }

        private void Initialize()
        {
            server = "localhost";
            database = "cantest";
            uid = "root";
            password = "ScramjetEngine11";
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";"; 

            
        }
        public void connect()
        {
            Initialize(); //creating connection string
            Debug.WriteLine("Connection_string:");//writing notification to debug
            Debug.WriteLine(connectionString);//writing connection string
            connection = new MySqlConnection(connectionString);//creating the connection object
        }

        public void readData()
        {
            connect();
            string sql = "SELECT frame_id, frame_name FROM frames";
            connection.Open();
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                MessageBox.Show(rdr[0] + " -- " + rdr[1]);
            }
            rdr.Close();
            connection.Close();
        }

        public void readDevices()
        {
            connect();//creating connection object
            string sql = "SELECT device_id, device_name, device_description FROM can_devices";//creating the query
            canDevices.Clear();//initialize the storage, that will hold the results
            connection.Open();//estabilishing connection
            MySqlCommand cmd = new MySqlCommand(sql, connection);//creating the mysql command
            MySqlDataReader rdr = cmd.ExecuteReader();//executing the command
            CanDevice temp; //create a temporary object that will hold the currently extracted data
            while (rdr.Read()) //read the results, as long as there is record remaining
            {
                temp = new CanDevice();
                temp.ID = (uint)rdr[0];
                temp.name=(string)rdr[1];
                temp.description=(string)rdr[2];
                canDevices.Add(temp);
            }
            rdr.Close();
            connection.Close();
        }

        public void readTestSteps()
        {
            connect();
            TestSteps = new List<TestStep>();
            string sql = "SELECT test_id, frame_id_to_send, frame_data_to_send,frame_id_to_receive,frame_data_len, frame_timeout,test_name,test_description,test_enabled,related_device_id FROM can_test_cases";
            connection.Open();
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                TestStep temp = new TestStep();
                temp.ID = (uint)rdr[0];
                temp.frameToSend.ID = (uint)rdr[1];
                temp.frameToSend.DataL= (ulong)rdr[2];
                temp.frameToSend.DLEN=  (uint)rdr[4];
                temp.frameIDReceived = (uint)rdr[3];
                temp.frameTimeout=(uint)rdr[5];
                temp.name=(string)rdr[6];
                temp.description = (string)rdr[7];
                temp.enabled = (Boolean)rdr[8];
                temp.relatedDeviceID = (uint)rdr[9];
                TestSteps.Add(temp);
                //MessageBox.Show(temp.ID.ToString() + " -- " + temp.frameToSend.ID.ToString() + " -- " + temp.frameToSend.DataL.ToString()) ;
            }
            rdr.Close();
            connection.Close();
        }

        public void refreshCanDevices()
        {
            deleteTestSteps();
            connect();
            string sql = "";
            connection.Open();
            MySqlCommand cmd = new MySqlCommand("DELETE FROM can_devices where 1=1", connection);
            cmd.ExecuteNonQuery();


            for (int i = 0; i < canDevices.Count; i++)
            {
                sql = "INSERT INTO can_devices(device_id,device_name,device_description) VALUES (@ID,@NAME,@DESCRIPTION)";
                cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@ID", canDevices[i].ID);
                cmd.Parameters.AddWithValue("@NAME", canDevices[i].name);
                cmd.Parameters.AddWithValue("@DESCRIPTION", canDevices[i].description);
                //MessageBox.Show(temp.ID.ToString() + " -- " + temp.frameToSend.ID.ToString() + " -- " + temp.frameToSend.DataL.ToString()) ;
                cmd.ExecuteNonQuery();
            }
            connection.Close();
            insertTestSteps();
        }
        public void deleteTestSteps()
        {
            connect();
            string sql = "";
            connection.Open();
            MySqlCommand cmd = new MySqlCommand("DELETE FROM can_test_cases where 1=1", connection);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void insertTestSteps()
        {
            connect();
            string sql = "";
            connection.Open();
            MySqlCommand cmd;
            for (int i = 0; i < TestSteps.Count; i++)
            {
                sql = "INSERT INTO can_test_cases(frame_id_to_send,frame_data_to_send,frame_data_len,frame_id_to_receive,frame_timeout,test_name," +
                    "test_description,test_enabled,related_device_id) " +
                    "VALUES (@IDsend,@data,@datalen,@IDreceive,@timeout,@testname,@description,@enabled,@related)";
                cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@IDsend", TestSteps[i].frameToSend.ID);
                cmd.Parameters.AddWithValue("@data", TestSteps[i].frameToSend.DataL);
                cmd.Parameters.AddWithValue("@datalen", TestSteps[i].frameToSend.DLEN);
                cmd.Parameters.AddWithValue("@IDreceive", TestSteps[i].frameIDReceived);
                cmd.Parameters.AddWithValue("@timeout", TestSteps[i].frameTimeout);
                cmd.Parameters.AddWithValue("@testname", TestSteps[i].name);
                cmd.Parameters.AddWithValue("@description", TestSteps[i].description);
                cmd.Parameters.AddWithValue("@enabled", TestSteps[i].enabled);
                cmd.Parameters.AddWithValue("@related", TestSteps[i].relatedDeviceID);
                //MessageBox.Show(temp.ID.ToString() + " -- " + temp.frameToSend.ID.ToString() + " -- " + temp.frameToSend.DataL.ToString()) ;
                cmd.ExecuteNonQuery();
            }
            connection.Close();
        }
        public void refreshTestSteps()
        {
            deleteTestSteps();
            insertTestSteps();
            
        }

        public void putFrameToDB(TrafficElementCanDataFrame cdf)
        {
            connect();
            string sql = "INSERT INTO can_traffic(frame_id,frame_data, frame_data_len,frame_time, direction) VALUES (@IDsend,@data,@datalen,@frame_time,@direction)";
            connection.Open();

                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@IDsend", cdf.canDataFrame.ID);
                cmd.Parameters.AddWithValue("@data", cdf.canDataFrame.DataL);
                cmd.Parameters.AddWithValue("@datalen", cdf.canDataFrame.DLEN);
                cmd.Parameters.AddWithValue("@frame_time", cdf.timeStamp);
                cmd.Parameters.AddWithValue("@direction", cdf.direction);
                //MessageBox.Show(temp.ID.ToString() + " -- " + temp.frameToSend.ID.ToString() + " -- " + temp.frameToSend.DataL.ToString()) ;
                cmd.ExecuteNonQuery();

            connection.Close();
        }

        public void DeleteFramesFromDB()
        {
            connect();
            string sql = "";
            connection.Open();
            MySqlCommand cmd = new MySqlCommand("DELETE FROM can_traffic where 1=1", connection);
            cmd.ExecuteNonQuery();
        }
    }
}
