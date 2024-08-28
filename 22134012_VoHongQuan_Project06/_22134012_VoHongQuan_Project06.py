import cv2
import numpy as np

img = cv2.imread('lena_color.png')
cv2.imshow("original", img)

R = img[:, :, 2]  # Red channel
G = img[:, :, 1]  # Green channel
B = img[:, :, 0]  # Blue channel

zero = np.zeros_like(R)  # Create zeroed out arrays for red, green, and blue channels

cyan = np.dstack((B, G, zero))  # Create cyan image
magenta = np.dstack((B, zero, R))  # Create magenta image
yellow = np.dstack((zero, G, R))  # Create yellow image

# Create key image by taking element-wise maximum of R, G, and B channels
key = np.minimum(B, G, R)

# Display images

cv2.imshow("cyan", R)
# cv2.imshow("magenta", magenta)
# cv2.imshow("yellow", yellow)
# cv2.imshow("black", key)

cv2.waitKey(0)
cv2.destroyAllWindows()
