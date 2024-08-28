import cv2
import numpy as np

# Load the image
img = cv2.imread('lena_color.png')

B = np.array(img[:, :, 0]).reshape(1, -1)
G = np.array(img[:, :, 1]).reshape(1, -1)
R = np.array(img[:, :, 2]).reshape(1, -1)

RGB = np.concatenate([R, G, B], axis= 0)

# array = np.array(([1, 2, 3], 
#                  [4, 5, 6], 
#                  [7, 8, 9]))
# barray = np.array(([3, 4, 1],
#                  [1, 2, 3],
#                  [2, 2, 2]))
# A = np.dot(array, barray)
# print(A)
# Separate color channels
# B = np.array(img[:, :, 0])
# G = np.array(img[:, :, 1])
# R = np.array(img[:, :, 2])
# zero = np.zeros_like(B)

# # Transformation matrix for color conversion
array = np.array([[65.738/256, 129.057/256, 25.064/256],
                  [-37.945/256, -74.494/256, 112.439/256], 
                  [112.439/256, -94.154/256, -18.285/256]])

A = np.matmul(array, RGB) + np.array([[16], [128], [128]])

Y = np.reshape(A[0, :], (512, 512))
Cb = np.reshape(A[1, :], (512, 512))
Cr = np.reshape(A[2, :], (512, 512))

# # Calculate X, Y, Z using the transformation matrix
# Y = 16 + array[0, 0] * R + array[0, 1] * G + array[0, 2] * B
# Cb = 128+ array[1, 0] * R + array[1, 1] * G + array[1, 2] * B
# Cr = 128+ array[2, 0] * R + array[2, 1] * G + array[2, 2] * B

# # Stack X, Y, Z channels to create the XYZ image
YCbCr = np.stack((Cr, Cb, Y), axis=-1)

# # Display the XYZ image and its channels
cv2.imshow('Y Image', Y.astype(np.uint8))
cv2.imshow('Cb Image', Cb.astype(np.uint8))
cv2.imshow('Cr Image', Cr.astype(np.uint8))
cv2.imshow('YCbCr Image', YCbCr.astype(np.uint8))

# Wait for a key press and close all windows
cv2.waitKey(0)
cv2.destroyAllWindows()

