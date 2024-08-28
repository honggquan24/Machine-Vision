import numpy as np
import cv2 as cv
import matplotlib.pyplot as plt 

def histogramGray(array):
    new_darray = np.zeros((256,))  # Initialize an array to hold the histogram counts
    
    for i in range(256):  # Fix the range to include 256
        new_darray[i] = np.count_nonzero((array == i))

    plt.bar(range(len(new_darray)), new_darray, color='gray', alpha=0.5)
    plt.xlabel('Value')
    plt.ylabel('Frequency')
    plt.title('Histogram of Grayscale Image')

    
def histogramRGB(img):
    new_darray_red = np.zeros((256,))  # Initialize arrays to hold the histogram counts
    new_darray_green = np.zeros((256,))
    new_darray_blue = np.zeros((256,))
    
    R = img[:, :, 2]
    G = img[:, :, 1]
    B = img[:, :, 0]
    
    for i in range(256):  # Fix the range to include 256
        new_darray_red[i] = np.count_nonzero((R == i))
        new_darray_green[i] = np.count_nonzero((G == i))
        new_darray_blue[i] = np.count_nonzero((B == i))

    plt.bar(range(len(new_darray_red)), new_darray_red,  color='red', alpha=0.5, label='Red')
    plt.bar(range(len(new_darray_green)), new_darray_green, color= 'green', alpha=0.5, label='Green')
    plt.bar(range(len(new_darray_blue)), new_darray_blue, color= 'blue', alpha=0.5, label='Blue')
    plt.xlabel('Value')
    plt.ylabel('Frequency')
    plt.title('Histogram of RGB Image')
    plt.legend()


img = cv.imread('bird_small.jpg')
gray = cv.cvtColor(img, cv.COLOR_BGR2GRAY)

plt.figure(figsize=(5, 10))

plt.subplot(1, 2, 1)
histogramGray(gray)

plt.subplot(1, 2, 2)
histogramRGB(img)

plt.show()

cv.waitKey(0)
cv.destroyAllWindows()
