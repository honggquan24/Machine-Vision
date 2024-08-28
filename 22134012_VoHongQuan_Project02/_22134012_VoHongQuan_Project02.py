import cv2
import numpy as np 
import matplotlib as plt 

# Đọc ảnh từ đường dẫn file
img = cv2.imread("C:/Users/ADMIN/Pictures/co_gai_lena.jpg", cv2.IMREAD_COLOR)

# Take shape of picture
height, width, Layer = img.shape

# Creare matrix of 
red = np.zeros((img.shape), np.uint8)
green = np.zeros((img.shape), np.uint8)
blue = np.zeros((img.shape), np.uint8)

# python 
R = img[:, :, 2]
G = img[:, :, 1]
B = img[:, :, 0]

# red, green, blue
red[:, :, 2] = R
green[:, : ,1] = G
blue[:, :, 0] = B

# # Seperate color channels 
# for i in range(height):
#     for j in range(width):
#         r = img[i, j, 2]
#         g = img[i , j, 1]
#         b = img[i, j, 0]
        
#         # Display the original and separated color channels
#         red[i ,j, 2] = r
#         green[i ,j, 1] = g
#         blue[i ,j, 0] = b

# Show picture  

cv2.imshow('co gai lena', img)
cv2.imshow('Vo Hong Quan _ 22134012', red)
cv2.imshow('Vo Hong Quan _ 22134012 ', green)
cv2.imshow('Vo Hong Quan _ 22134012  ', blue)

# cv2.imwrite('Red.jpg', red)
# cv2.imwrite('Blue.jpg', blue)
# cv2.imwrite('Green.jpg', green)

# Wait for a key press and close all windows
cv2.waitKey(60000)
cv2.destroyAllWindows()
