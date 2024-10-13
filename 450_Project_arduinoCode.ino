//450 project that will use 2 languages 
//our languages will be C# and arduino
//project by Andrew Naylor, Joe in the back, and Joshua Jenkins 
#include <Servo.h>


int redLED= 3; // the pin on the arduino that the red LED is connecte to
int greenLED = 2; //the pin on the arduino that the green Led is connected to
String check;
bool lock; //this will be set by the c# code

;
Servo lockServo; 
// we will need a method that checks some value from C# program, and changes lock bool value
  

void setup() {
  
  Serial.begin(9600);// starts the serial that we will communicate with through C#

  // in the setup we will assign the pins 
  pinMode(redLED, OUTPUT);
  pinMode(greenLED, OUTPUT);
  lockServo.attach(4);

}

void loop() {
  //this will read string from c# program
  //if it reads a 0, lock
  //else unlock
  if(Serial.available()){
    check = Serial.readString();
    char ch = check.charAt(0);
    if(ch =='0'){
      lock = true;
    }else{
      lock = false;
    }
  }
  //will need to continuoudly check the value returned by the c# program to tell weather to unlock the box, or keep it locked 
  // put your main code here, to run repeatedly:
  if ( lock == false ){
    lockServo.write(160);
    digitalWrite(redLED,LOW);
    digitalWrite(greenLED,HIGH);
    
  }else{
    //put the servo into the locked pos.
    lockServo.write(60);
    digitalWrite(redLED,HIGH);
    digitalWrite(greenLED,LOW);

  }
 
}
