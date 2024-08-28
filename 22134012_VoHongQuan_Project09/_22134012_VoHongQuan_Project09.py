from traceback import print_tb
import cv2
import numpy as np

# Load the image
img = cv2.imread('lena_color.png')

# Separate color channels
B = np.array(img[:, :, 0])
G = np.array(img[:, :, 1])
R = np.array(img[:, :, 2])
zero = np.zeros_like(B)

# Transformation matrix for color conversion
array = np.array([[0.4124564, 0.3575761, 0.18043757],
                  [0.2126729, 0.7151522, 0.0721750], 
                  [0.0193339, 0.1191920, 0.9503041]])

# Calculate X, Y, Z using the transformation matrix
X = array[0, 0] * R + array[0, 1] * G + array[0, 2] * B
Y = array[1, 0] * R + array[1, 1] * G + array[1, 2] * B
Z = array[2, 0] * R + array[2, 1] * G + array[2, 2] * B
i = np.ones_like(img)
print(i.shape)
# Stack X, Y, Z channels to create the XYZ image
XYZ = np.stack((Z, Y, X), axis=-1)

# Display the XYZ image and its channels
cv2.imshow('X Image', X.astype(np.uint8))
cv2.imshow('Y Image', Y.astype(np.uint8))
cv2.imshow('Z Image', Z.astype(np.uint8))
cv2.imshow('XYZ Image', XYZ.astype(np.uint8))

# Wait for a key press and close all windows
cv2.waitKey(0)
cv2.destroyAllWindows()
