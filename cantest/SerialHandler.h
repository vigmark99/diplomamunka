#define DRIVE_IDENTIFIER "<drive>"
#define DRIVE_IDENTIFIER_ENDING "</drive>"
#define HANDSHAKE_IDENTIFIER "<hndsk>"
#define HANDSHAKE_IDENTIFIER_ENDING "</hndsk>"
#define FRAME_IDENTIFIER "<frame>"
#define FRAME_IDENTIFIER_ENDING "</frame>"
#define SERIAL_MSG_TERMINATOR '\n'


class SerialHandler {
  private:
    long LastTime;
    int randID;
    int ConnectionState = 0;
    bool canMsgReadyToSend=false;
    bool isDriveMessage(String msg)
    {
      return msg.startsWith(String(DRIVE_IDENTIFIER)) && msg.endsWith(String(DRIVE_IDENTIFIER_ENDING));
    }
    bool isFrameMessage(String msg)
    {
      return msg.startsWith(String(FRAME_IDENTIFIER)) && msg.endsWith(String(FRAME_IDENTIFIER_ENDING));
    }
    bool isHandshakeMessage(String msg)
    {
      return msg.startsWith(String(HANDSHAKE_IDENTIFIER)) && msg.endsWith(String(HANDSHAKE_IDENTIFIER_ENDING));
    }

    String trimToNextLevel(String msg)
    {
      msg.remove(msg.length() - String(DRIVE_IDENTIFIER_ENDING).length(), String(DRIVE_IDENTIFIER_ENDING).length());
      msg.remove(0, String(DRIVE_IDENTIFIER).length());
      return msg;
    }
  public:
    SerialHandler()
    {

    }
    int getConnectionState() {
      return ConnectionState;
    }
    void processNextMessage()
    {
      String msg = Serial.readStringUntil(SERIAL_MSG_TERMINATOR);
      msg.trim();
      if (isDriveMessage(msg))
      {
        msg = trimToNextLevel(msg);
        if (isHandshakeMessage(msg))
        {
          msg = trimToNextLevel(msg);
          if (ConnectionState == 0 || ConnectionState == 2)
          {
            randID = msg.toInt();
            randID++;
            String s(randID);
            Serial.print(String(DRIVE_IDENTIFIER) + String(HANDSHAKE_IDENTIFIER) + String(s) + String(HANDSHAKE_IDENTIFIER_ENDING) + String(DRIVE_IDENTIFIER_ENDING) + String(SERIAL_MSG_TERMINATOR));
            ConnectionState = 1;
            
          }
          else if (ConnectionState == 1 && msg.toInt() == ++randID)
          {
            ConnectionState = 2;
          }
          else
          {
            ConnectionState = 0;
          }
        }
      }
      else if (isFrameMessage(msg))
      {
        msg = trimToNextLevel(msg);
        char buf[50];
        msg.toCharArray(buf, 50);
        int substr = 0;
        char* str;
        char* p = buf;
        while ((str = strtok_r(p, " ", &p)) != NULL) // delimiter is the semicolon
        {
          uint32_t tempnum = (uint32_t)atoi(str);
          uint8_t tempbyte=(uint8_t) tempnum;
          //Serial.println(tempnum);
          switch (substr)
          {
            case 0: canMsg.can_id  = tempnum; substr++; break;
            case 1: canMsg.can_dlc  = tempbyte; substr++; canMsgReadyToSend = (canMsg.can_dlc <= 0) ? true : false; break;
            case 2: canMsg.data[0]  = tempbyte; substr++; canMsgReadyToSend = (canMsg.can_dlc <= 1) ? true : false; break;
            case 3: canMsg.data[1]  = tempbyte; substr++; canMsgReadyToSend = (canMsg.can_dlc <= 2) ? true : false; break;
            case 4: canMsg.data[2]  = tempbyte; substr++; canMsgReadyToSend = (canMsg.can_dlc <= 3) ? true : false; break;
            case 5: canMsg.data[3]  = tempbyte; substr++; canMsgReadyToSend = (canMsg.can_dlc <= 4) ? true : false; break;
            case 6: canMsg.data[4]  = tempbyte; substr++; canMsgReadyToSend = (canMsg.can_dlc <= 5) ? true : false; break;
            case 7: canMsg.data[5]  = tempbyte; substr++; canMsgReadyToSend = (canMsg.can_dlc <= 6) ? true : false; break;
            case 8: canMsg.data[6]  = tempbyte; substr++; canMsgReadyToSend = (canMsg.can_dlc <= 7) ? true : false; break;
            case 9: canMsg.data[7]  = tempbyte; substr++; canMsgReadyToSend = (canMsg.can_dlc <= 8) ? true : false; break;
            default:
            substr++;
              break;
          };
        }
        if (canMsgReadyToSend)
        {
          //Serial.println(String("valid ") + String(canMsg.can_id) + " " + String(canMsg.can_dlc)+" " + String(canMsg.data[0]));
          mcp2515.sendMessage(&canMsg);
        }
        else
        {
          //Serial.println("error");
        }
        canMsgReadyToSend = false;
      }
      else if (msg != "" && ConnectionState != 2)
      {
        ConnectionState = 0;
      }
    }

};
