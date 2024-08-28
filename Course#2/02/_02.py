import numpy as nop 
import matplotlib.pyplot as plt
import cv2



# load 
cell1 = cv2.imread('cell1.jpg', cv2.IMREAD_COLOR)
noise1 = cv2.imread('noise1.jpg', cv2.IMREAD_COLOR)

# gray 
cell1_gray = cv2.cvtColor(cell1, cv2.COLOR_BGR2GRAY)
noise1_gray = cv2.cvtColor(noise1, cv2.COLOR_BGR2GRAY)

# noise filter 
### cell1
cell1_gray = cv2.medianBlur(cell1_gray, 3)
# cell1_gray = cv2.blur(cell1_gray, (3,3))
# cell1_gray = cv2.GaussianBlur(cell1_gray, (3, 3), 0)

### noise1
# noise1_gray = cv2.medianBlur(noise1_gray, 3)
# noise1_gray = cv2.blur(noise1_gray, (3,3))
# noise1_gray = cv2.GaussianBlur(noise1_gray, (3,3), 0)

# thresh
cell1_bin = cv2.threshold(cell1_gray, 180, 255, cv2.THRESH_BINARY_INV)[1]
noise1_bin = cv2.threshold(noise1_gray, 95, 255, cv2.THRESH_BINARY_INV)[1]

# cv2.imshow('noise1_gray', noise1_gray)
# cv2.imshow('noise1_bin', noise1_bin)

# Contour
# contours_cell1, hierarchy_cell1 = cv2.findContours(cell1_bin, cv2.RETR_EXTERNAL, cv2.CHAIN_APPROX_NONE)
# contours_noise1, hierarchy_noise1 = cv2.findContours(noise1_bin, cv2.RETR_EXTERNAL, cv2.CHAIN_APPROX_NONE)

# erode, dilate
cell1_bin_1 = cv2.erode(cell1_bin, (7,7), None, (-1, -1), 7)
cell1_bin_2 = cv2.dilate(cell1_bin_1, (3,3), None, (-1,-1), 10)

# distance transform 
cell1_bin_dist = cv2.distanceTransform(cell1_bin_2, cv2.DIST_L2, 3)

# normalization
cv2.normalize(cell1_bin_dist, cell1_bin_dist, 0, 1, cv2.NORM_MINMAX)

# out
out = cv2.threshold(cell1_bin_dist, 0.15, 1, cv2.THRESH_BINARY)[1]

cv2.imshow('cell1_bin', cell1_bin_2)
cv2.imshow('cell1_bin_1', out)

# draw
# for contour in contours_noise1:
#     (x, y),radius = cv2.minEnclosingCircle(contour)
#     center = (int(x), int(y))
#     radius = int(radius)
#     cv2.circle(noise1, center, radius, (255,0,0), 2, cv2.FILLED)
    
# plt.hist(cell1_gray.ravel(), 256, [0, 256])
# plt.show()

# cv2.imshow('cell1', cell1)
# cv2.imshow('noise1', noise1)
# cv2.imshow('cell1_gray', cell1_gray)
# cv2.imshow('noise1_gray', noise1_gray)

# 
cv2.waitKey(0)
cv2.destroyAllWindows()
