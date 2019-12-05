BROADCAST_TO_PORT = 6969
SLEEP_SEC = 5 #skal være 600
from datetime import datetime
from sense_hat import SenseHat
sense = SenseHat()  
now = datetime.now()
import json
import time

from socket import *

url = 'http://voresvejrstation.azurewebsites.net/api/WeatherDatas'
#payload = {'Temperature: ': ''}

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
    
    data = "T: " + str(t) + " P: " + str(p) + " H: " + str(h) + " Time: " + str(now.strftime("%d/%m/%Y %H:%M:%S"))
    s.sendto(bytes(data, "UTF-8"), ('<broadcast>', BROADCAST_TO_PORT))
    sense.show_message(data, scroll_speed=0.05)
    print(data)
    time.sleep(SLEEP_SEC)