import socket
import json

localHost = "10.200.179.232"
serverPort = 12002
clientSocket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
clientSocket.connect((localHost, serverPort))

keep_communicating = True
while keep_communicating:
    print("\nPossible operations: Random/Add/Subtract or Exit to end.")
    operation = input("Input operation: ").lower()
    if operation == "exit":
        keep_communicating = False
    else:
        num1 = input("Input number 1: ")
        num2 = input("Input number 2: ")

        JsonData = {"Operation": f"{operation}",
                    "Number1": f"{num1}",
                    "Number2": f"{num2}"}
        
        JsonFile = json.dumps(JsonData)

        clientSocket.sendall(bytes(JsonFile, encoding = "utf-8"))
        result = clientSocket.recv(1024).decode()
        print("From server: ", result)
clientSocket.close()