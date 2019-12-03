from datetime import datetime
from sense_hat import SenseHat
sense = SenseHat()
now = datetime.now()
import json
import time
from csv import writer
import csv

with open('data.csv', 'w', newline='') as f:
    writer = csv.writer(f)
while True:
    def get_sense_data():
        sense_data = []
        sense_data.append(sense.get_temperature_from_humidity())
        sense_data.append(sense.get_pressure())
        sense_data.append(sense.get_humidity())
    
    # Take readings from all three sensors
    t = sense.get_temperature_from_humidity()
    p = sense.get_pressure()
    h = sense.get_humidity()
    #writer.writerow
    # Round the values to one decimal place
    t = round(t, 1)
    p = round(p, 1)
    h = round(h, 1)
    
   # message = return sense_data
    message = "T: " + str(t) + " P: " + str(p) + " H: " + str(h) + " Time: " + str(now.strftime("%d/%m/%Y, %H:%M:%S"))
    
    sense.show_message(message, scroll_speed=0.05)
    data_list = []
    data_list.append(message)
    jsonString = json.dumps(message, time.sleep(5)) 


#import time
#from datetime import datetime
#now = datetime.now()
#import json
#from csv import writer
#import csv
#
#with open('data.csv', 'w', newline='') as f:
#    writer = csv.writer(f)
#
#message = "Time: " + str(now.strftime("%d/%m/%Y, %H:%M:%S"))
#jsonString = json.dumps(message)
#def get_sense_data():
#        sense_data = []
#        sense_data.append(sense.get_temperature_from_humidity())
#        sense_data.append(sense.get_pressure())
#        sense_data.append(sense.get_humidity())
#data_list = []
#    data_list.append(message)
#    writer.writerow
    