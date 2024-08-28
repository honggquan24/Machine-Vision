import numpy as np
import cv2 as cv

def edge_gray(image, threshold):
    Sx = np.array([[-1, -2, -1], [0, 0, 0], [1, 2, 1]])
    Sy = np.array([[-1, 0, 1], [-2, 0, 2], [-1, 0, 1]])

    width, height,_ = image.shape
    pixels = cv.cvtColor(image, cv.COLOR_BGR2GRAY)  # Convert image to grayscale

    new_image = np.zeros_like(pixels)

    for x in range(1, width-1):
        for y in range(1, height-1):
            gx = np.sum(np.multiply(Sx, pixels[x-1:x+2, y-1:y+2]))
            gy = np.sum(np.multiply(Sy, pixels[x-1:x+2, y-1:y+2]))

            gradient_magnitude = abs(gx) + abs(gy)

            if gradient_magnitude > threshold:
                new_image[x, y] = 255  # Set pixel to white
            else:
                new_image[x, y] = 0  # Set pixel to black

    return new_image


img = cv.imread(r"C:\Data\Machine Vision\lena_color.png") # Corrected path
edge = edge_gray(img, 15)

cv.imshow('Original', img)
cv.imshow('Edge Detection', edge)

cv.waitKey(0)
cv.destroyAllWindows()
