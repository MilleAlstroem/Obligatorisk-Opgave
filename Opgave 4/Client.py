import socket

localHost = "192.168.1.238"
serverPort = 12000
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

    sentence = f"{operation};{num1};{num2}"
    clientSocket.send(sentence.encode())
    modifiedSentence = clientSocket.recv(1024).decode()
    print('From server: ', modifiedSentence)
clientSocket.close()