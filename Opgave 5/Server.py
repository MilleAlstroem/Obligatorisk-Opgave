import socket
import threading
import random
import json

def handle_client(connectionSocket, addr):
    print(addr[0])
    
    keep_communicating = True
    while keep_communicating:
        data = connectionSocket.recv(1024).decode()
        data = json.loads(data)
        
        result = "ERROR: Enter valid calculation."
        
        operation = data["Operation"]
        if(data["Number1"].isnumeric() and data["Number2"].isnumeric()):
            num1 = int(data["Number1"])
            num2 = int(data["Number2"])

        if operation == "exit":
               keep_communicating = False
               result = "Closing server"
        elif operation == "random":
                    result = random.randint(num1, num2)
        elif operation == "add":
                    result = num1 + num2
        elif operation == "subtract":
                    result = num1 - num2
         
        connectionSocket.send(str(result).encode())
    connectionSocket.close()

localHost = "10.200.179.232"
serverPort = 12002
serverSocket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
serverSocket.bind((localHost, serverPort))
serverSocket.listen(1)
print('Server is ready to listen')

while True:
    connectionSocket, addr = serverSocket.accept()
    threading.Thread(target=handle_client, args=(connectionSocket, addr)).start()