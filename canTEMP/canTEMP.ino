#include <SPI.h>
#include <mcp2515.h>
#include "DHT.h"
#include "vector.h"
#define DHTPIN 3
#define DHTTYPE DHT11
#define LEDPIN1 5
#define LEDPIN2 6
#define LEDPIN3 7
#define LEDPIN4 8
DHT dht(DHTPIN, DHTTYPE);

union Temperature { float f; byte b[4]; };

Temperature temperature;

struct can_frame canMsg;
struct can_frame canReply;
MCP2515 mcp2515(10);

bool turnedOn=false;
bool DHT11TurnedOn=false;
bool ledTurnedOn=false;

byte counter=0;

long lastMillis=0;
long lastMillis2=0;
long lastMillis3=0;

struct IDcallback{
  uint32_t ID;
  void (*f)(can_frame cdf);
};

vector<IDcallback> v;

void task1();

void task2();

void setup() {
  Serial.begin(115200);

  IDcallback* cbk1=new IDcallback();
  cbk1->ID=109;
  cbk1->f=task4;
  v.add(*cbk1);

  cbk1=new IDcallback();
  cbk1->ID=110;
  cbk1->f=task5;
  v.add(*cbk1);

  cbk1=new IDcallback();
  cbk1->ID=103;
  cbk1->f=task6;
  v.add(*cbk1);

  cbk1=new IDcallback();
  cbk1->ID=100;
  cbk1->f=task7;
  v.add(*cbk1);
  
  mcp2515.reset();
  mcp2515.setBitrate(CAN_125KBPS);
  mcp2515.setNormalMode();
  dht.begin();
}

void loop() {
  task1();
  task2();
  task3();
  
  
}

void task1()
{
  if (mcp2515.readMessage(&canMsg) == MCP2515::ERROR_OK) {
    for(int i=0; i<v.size(); i++)
    {
      if(v[i].ID==canMsg.can_id)
        v[i].f(canMsg);
    }
  }
}
void task2()
{
  if(millis()-lastMillis>1000 && turnedOn)
  {
      canReply.can_id  = 105;
      canReply.can_dlc = 8;
      canReply.data[0] = counter;
      counter++;
      mcp2515.sendMessage(&canReply);
      //Serial.println("sended");
      lastMillis=millis();
  }
}

void task3()
{
  if(millis()-lastMillis2>10000 && DHT11TurnedOn)
  {
      float h = dht.readHumidity();
      // Read temperature as Celsius (the default)
      temperature.f = dht.readTemperature();
      // Read temperature as Fahrenheit (isFahrenheit = true)
      float f = dht.readTemperature(true);
    
      // Check if any reads failed and exit early (to try again).
      if (isnan(h) || isnan(temperature.f) || isnan(f)) {
        //Serial.println(F("Failed to read from DHT sensor!"));
        canReply.can_id  = 108;
      canReply.can_dlc = 1;
      canReply.data[0] = 0xFF;
      mcp2515.sendMessage(&canReply);
        return;
      }
      canReply.can_id  = 107;
      canReply.can_dlc = 4;
      canReply.data[0] = temperature.b[0];
      canReply.data[1] = temperature.b[1];
      canReply.data[2] = temperature.b[2];
      canReply.data[3] = temperature.b[3];
      mcp2515.sendMessage(&canReply);
      //Serial.println("sended");
      lastMillis2=millis();
  }
}

void task4(can_frame cdf)
{
  switch(cdf.data[0])
  {
    case 8: digitalWrite(LEDPIN1, LOW); break;
    case 1: digitalWrite(LEDPIN1, HIGH); break;
    case 2: digitalWrite(LEDPIN2, LOW); break;
    case 3: digitalWrite(LEDPIN2, HIGH); break;
    case 4: digitalWrite(LEDPIN3, LOW); break;
    case 5: digitalWrite(LEDPIN3, HIGH); break;
    case 6: digitalWrite(LEDPIN4, LOW); break;
    case 7: digitalWrite(LEDPIN4, HIGH); break;
    default: break;
  }
}

void task5(can_frame cdf)
{
  DHT11TurnedOn=!DHT11TurnedOn;
}
void task6(can_frame cdf)
{
  turnedOn=!turnedOn;
      canReply.can_id  = 104;
      canReply.can_dlc = 0;
      mcp2515.sendMessage(&canReply);
}
void task7(can_frame cdf)
{
  canReply.can_id  = 101;
  canReply.can_dlc = 0;
  mcp2515.sendMessage(&canReply);
  //Serial.println("sended");
}
