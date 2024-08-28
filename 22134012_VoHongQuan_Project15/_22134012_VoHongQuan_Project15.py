from tkinter import Image
import numpy as np
import cv2 as cv

def edge_color(image, threshold):
    Sx = np.array([[-1, -2, -1], [0, 0, 0], [1, 2, 1]])
    Sy = np.array([[-1, 0, 1], [-2, 0, 2], [-1, 0, 1]])

    width, height,_ = image.shape
    pixels = cv.cvtColor(image, cv.COLOR_BGR2GRAY)  # Convert image to grayscale

    R = image[:, :, 2]
    G = image[:, :, 1]
    B = image[:, :, 0]

    new_image = np.zeros_like(pixels)

    for x in range(1, width-1, 1):
        for y in range(1, height-1, 1):

            
            gxR = np.sum(np.multiply(Sx, R[x-1:x+2, y-1:y+2]))     
            gyR = np.sum(np.multiply(Sy, R[x-1:x+2, y-1:y+2]))
            
            gxG = np.sum(np.multiply(Sx, G[x-1:x+2, y-1:y+2]))
            gyG = np.sum(np.multiply(Sy, G[x-1:x+2, y-1:y+2]))

            gxB = np.sum(np.multiply(Sx, B[x-1:x+2, y-1:y+2]))
            gyB = np.sum(np.multiply(Sy, B[x-1:x+2, y-1:y+2]))
            
            gradient_magnitude_xx = abs(gxR)**2 + abs(gxG)**2 + abs(gxB)**2
            gradient_magnitude_yy = abs(gyR)**2 + abs(gyG)**2 + abs(gyB)**2
            gradient_magnitude_xy = abs(gyR)*abs(gxR) + abs(gyG)*abs(gxG) + abs(gyB)*abs(gxB)


            theta = 0.5 * np.arctan2((2 * gradient_magnitude_xy), (gradient_magnitude_xx - gradient_magnitude_xy))
             
            F0 = np.sqrt(0.5 * ((gradient_magnitude_xx + gradient_magnitude_yy) + (gradient_magnitude_xx - gradient_magnitude_yy) * np.cos(2 * theta)))
            
            if F0 >= threshold:
                new_image[x, y] = 255  # Set pixel to white m
            else:
                new_image[x, y] = 0  # Set pixel to black
            
    return new_image


img = cv.imread(r"C:\Data\Machine Vision\lena_color.png") # Corrected path
edge = edge_color(img, 45)

cv.imshow('Original', img)
cv.imshow('Edge Detection', edge)

cv.waitKey(0)
cv.destroyAllWindows()

