import cv2 as cv 
import numpy as np 

# Load file
img = cv.imread(r"C:\Data\Machine Vision\lena_color.png", cv.IMREAD_GRAYSCALE)

# Segmentation
thresh = 100 
_, b_img = cv.threshold(img, thresh, 255, cv.THRESH_BINARY) 

# Convert to numpy array (unnecessary in this case)
b_img = np.asarray(b_img)

# Display segmented image
cv.imshow("Segmented Image", b_img)
cv.imshow("Segmented Image Binary", img)
cv.waitKey(0)
cv.destroyAllWindows()
