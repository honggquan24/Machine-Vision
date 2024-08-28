import numpy as np 
import cv2 as cv
import matplotlib.pyplot as plt 

path = "C:\Data\Machine Vision\lena_color.png"
ball_gray = "C:\Data\Machine Vision\Course#2\Data\sample.png"

# Load image 
i_lena = cv.imread(path, cv.IMREAD_COLOR)
i_pall = cv.imread(ball_gray, cv.IMREAD_COLOR)
i_pall_gray = cv.imread(ball_gray, cv.IMREAD_GRAYSCALE)
i_sample_otsu = cv.imread("C:\Data\Machine Vision\Course#2\Data\sample1.jpg", cv.IMREAD_COLOR)
i_sample_otsu_gray = cv.imread("C:\Data\Machine Vision\Course#2\Data\sample1.jpg", cv.IMREAD_GRAYSCALE)


# Set thresh 
thresh = 150 
_, i_pall_in = cv.threshold(i_pall_gray, thresh, 255,  cv.THRESH_BINARY_INV | cv.THRESH_OTSU)
_, i_otsu_in = cv.threshold(i_sample_otsu_gray, thresh, 255,  cv.THRESH_BINARY_INV | cv.THRESH_OTSU)

# Show 

# cv.imshow('i_img', i_pall_in)
# cv.imshow('i_pall', i_pall)
# cv.imshow('i_pall_in', i_pall_in)

# Contour
contours, hierarchy = cv.findContours(i_otsu_in, cv.RETR_EXTERNAL, cv.CHAIN_APPROX_SIMPLE)

# Numbers of objects
# nums = len(contour)

# draw
for contour in contours:
    (x, y), radius = cv.minEnclosingCircle(contour)
    center = (int(x), int(y))
    radius = int(radius)
    cv.circle(i_sample_otsu, center, radius, (0, 255, 0), 2)
    
plt.hist(i_sample_otsu_gray.ravel(),256,[0,256]); plt.show()


# cv.imshow('i_pall', i_pall)
cv.imshow('i_sample_otsu', i_sample_otsu_gray)

# Print contour, hierarchy
# print('numbers of object', nums)
#print(contour)
#print(hierarchy)

# wait
cv.waitKey(0)
cv.destroyAllWindows() 



