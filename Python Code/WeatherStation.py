BROADCAST_TO_PORT = 6969
SLEEP_SEC = 600 #skal være 600(10 minutter) men test ved 5-15 sec
from datetime import datetime
from sense_hat import SenseHat
sense = SenseHat()  
now = datetime.now()
import json
import time

from socket import *

#sets the Ip locally 
ip = "127.0.0.1"
s = socket(AF_INET, SOCK_DGRAM)
s.setsockopt(SOL_SOCKET, SO_BROADCAST, 1)

while True:
    
    # Take readings from all three sensors
    t = sense.get_temperature_from_humidity()
    p = sense.get_pressure()
    h = sense.get_humidity()
    # Round the values to one decimal place
    t = round(t, 1)
    p = round(p, 1)
    h = round(h, 1)
    
    #define the sensor data
    data = "Pressure: " + str(t) + " Temperature: " + str(t) + " Humidity: " + str(h) + " Time: " + str(datetime.now())
    #broadcast the defined data
    s.sendto(bytes(data, "UTF-8"), ('<broadcast>', BROADCAST_TO_PORT))
    #show the data as a scrolling message on the display of the Raspberry Pi
    sense.show_message(data, scroll_speed=0.05)
    #Print the data to a message in the consol 
    print(data)
    #delays the next measurement by the amount of seconds specified in SLEEP_SEC (10 minutes)
    time.sleep(SLEEP_SEC)