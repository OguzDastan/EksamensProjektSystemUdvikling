from datetime import datetime
from sense_hat import SenseHat
sense = SenseHat()
now = datetime.now()
import json
import time
import requests
url = 'http://voresvejrstation.azurewebsites.net/api/WeatherDatas'
payload = {'Temperature: ': ''}


while True:
    
    # Take readings from all three sensors
    t = sense.get_temperature_from_humidity()
    p = sense.get_pressure()
    h = sense.get_humidity()
    # Round the values to one decimal place
    t = round(t, 1)
    p = round(p, 1)
    h = round(h, 1)
    
    message = "T: " + str(t) + " P: " + str(p) + " H: " + str(h) + " Time: " + str(now.strftime("%d/%m/%Y, %H:%M:%S"))
    
    sense.show_message(message, scroll_speed=0.05)
    jsonString = json.dumps(message, time.sleep(5)) # ret til 600 sec ved launch 
