from turtle import delay
import cv2
from numpy import gradient

cap = cv2.VideoCapture(0) 
img = cv2.imread("C:\Data\Machine Vision\Course#2\Data\eye.jpg")


gray_im = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)
threshold = 100 
binary = cv2.threshold(gray_im, threshold, 255, cv2.THRESH_BINARY_INV )[1]



cv2.imshow('im', binary)
# if not cap.isOpened():
#     print("Can't open camera.")
#     exit()

# while True: 
#     ret, frame = cap.read()
    
#     if not ret:
#         print('Not')
#         break 
    
#     cv2.imshow('Camera', frame)
    
#     print(frame)
    
#     if cv2.waitKey(1) & 0xFF == ord('q'):
#         break


cap.release()
cv2.waitKey(0)
cv2.destroyAllWindows()

