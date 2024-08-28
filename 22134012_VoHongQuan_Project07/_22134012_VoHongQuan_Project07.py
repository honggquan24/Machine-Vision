import cv2
import numpy as np

img = cv2.imread('lena_color.png')

# Seperate color channels
B = np.array(img[:, :, 0])
G = np.array(img[:, :, 1])
R = np.array(img[:, :, 2])
zero = np.zeros_like(B)

# Normalize
B = B / 255
G = G / 255
R = R / 255

numerator = ((R - G) + (R - B)) / 2
denominator = np.sqrt((R - G)**2 + (R - B)*(G - B))

theta = np.arccos(numerator/denominator)

Hue = np.where(B <= G, theta, (2*np.pi - theta))

Saturation = 1 - 3 * np.minimum(R, np.minimum(G, B)) / (R + G + B)

Intensity = (R + G + B) / 3

# Convert to 0-255 range
Hue = Hue * 180 / np.pi
Saturation = Saturation * 255
Intensity = Intensity * 255

# Stack channels for visualization
HSI = np.stack((Intensity, Saturation, Hue), axis=-1)
Hue = np.stack((Hue, Hue, Hue), axis=-1)
Saturation = np.stack((Saturation, Saturation, Saturation), axis=-1)
Intensity = np.stack((Intensity, Intensity, Intensity), axis=-1)


# Display HSI image
cv2.imshow('Hue Image', Hue.astype(np.uint8))
cv2.imshow('Saturation Image', Saturation.astype(np.uint8))
cv2.imshow('Intensity Image', Intensity.astype(np.uint8))
cv2.imshow('HSI Image', HSI.astype(np.uint8))


cv2.waitKey(0)
cv2.destroyAllWindows()
