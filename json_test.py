import time
from datetime import datetime
now = datetime.now()
import json

message = "Time: " + str(now.strftime("%d/%m/%Y, %H:%M:%S"))
jsonString = json.dumps(message)
