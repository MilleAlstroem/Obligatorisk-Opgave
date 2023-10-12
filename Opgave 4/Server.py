import socket
import threading
import random

def handle_client(connectionSocket, addr):
    print(addr[0])
    
    keep_communicating = True
    while keep_communicating:
        data = connectionSocket.recv(1024).decode().strip()
        print(data)

        result = "ERROR: Enter valid calculation."

        operation_list = data.split(";")
        if (len(operation_list) == 3):
            operation = str(operation_list[0]).lower()

            if(operation_list[1].isnumeric() and operation_list[2].isnumeric()):
                num1 = int(operation_list[1])
                num2 = int(operation_list[2])

                if operation == "random":
                    result = random.randint(num1, num2)
                elif operation == "add":
                    result = num1 + num2
                elif operation == "subtract":
                    result = num1 - num2
        
        result += "\n"  
        connectionSocket.send(str(result).encode())
    connectionSocket.close()

localHost = "192.168.1.238"
serverPort = 12000
serverSocket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
serverSocket.bind((localHost, serverPort))
serverSocket.listen(1)
print('Server is ready to listen')
while True:
    connectionSocket, addr = serverSocket.accept()
    threading.Thread(target=handle_client, args=(connectionSocket, addr)).start()