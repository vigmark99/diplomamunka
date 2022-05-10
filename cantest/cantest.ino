#include <mcp2515.h>

struct can_frame canMsg;
struct can_frame canMsg2;
bool canMsgReadyToSend=false;
MCP2515 mcp2515(10);

#include "SerialHandler.h"


SerialHandler sh;


void setup() {
  Serial.begin(115200);
  mcp2515.reset();
  mcp2515.setBitrate(CAN_125KBPS);
  mcp2515.setNormalMode();

}

void loop() {
  while(sh.getConnectionState()!=2)
    {
      sh.processNextMessage();
    }
    
    while(sh.getConnectionState()==2)
    {
      sh.processNextMessage();
            if (mcp2515.readMessage(&canMsg2) == MCP2515::ERROR_OK) {
            String temp("<frame>");
            temp+=String(canMsg2.can_id)+" ";
            temp+=String(canMsg2.can_dlc);
            for(int i=0; i<canMsg2.can_dlc; i++)
            {
              temp+=" "+String(canMsg2.data[i]);
            }
            temp+="</frame>";
            Serial.println(temp);
          }
      
    }

}
