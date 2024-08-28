# Import necessary libraries
from email.mime import image
import cv2
import numpy as np
# from PIL import Image

# Specify the file path
file_path = r"C:\Data\Machine Vision\lena_color.png"

# Read the image using cv2
image_cv2 = cv2.imread(file_path, cv2.IMREAD_COLOR)

average = np.zeros((image_cv2.shape[0], image_cv2.shape[1], 3))
lightness = np.zeros((image_cv2.shape[0], image_cv2.shape[1], 3))
luminance = np.zeros((image_cv2.shape[0], image_cv2.shape[1], 3))

average = np.uint8((image_cv2[:, :, 2] * 1/ 3 + image_cv2[:, :, 1] * 1/ 3 + image_cv2[:, :, 0] *  1/ 3) )
lightness = np.maximum(image_cv2[:, :, 2]) + np.minimum(image_cv2[:, :, 2])
luminace = np.uint8(image_cv2[:, :, 2] *0.2126 + image_cv2[:, :, 1] * 0.7152 + image_cv2[:, :, 0] *0.0722)


# Read the image using Pillow
# image_pil = Image.open(file_path)

# Create new images with properties similar to image_pil
# average = Image.new(mode=image_pil.mode, size=image_pil.size)
# lightness = Image.new(mode=image_pil.mode, size=image_pil.size)
# luminance = Image.new(mode=image_pil.mode, size=image_pil.size)

# Get the width and height of the image
# width, height = image_pil.size

# Loop through each pixel in the image
# for i in range(width):
#     for j in range(height):
#         # Get the RGB values of the pixel
#         R, G, B = image_pil.getpixel((i, j))

#         # Average method
#         gray_avg = np.uint8((R + G + B) / 3)
#         average.putpixel((i, j), (gray_avg, gray_avg, gray_avg))

#         # Lightness method
#         min_rgb = min(image_pil.getpixel((i, j)))
#         max_rgb = max(image_pil.getpixel((i, j)))
#         gray_lgt = np.uint8((min_rgb + max_rgb) / 2)
#         lightness.putpixel((i, j), (gray_lgt, gray_lgt, gray_lgt))

#         # Luminance method
#         gray_lumi = np.uint8(0.2126 * R + 0.7152 * G + 0.0722 * B)
#         luminance.putpixel((i, j), (gray_lumi, gray_lumi, gray_lumi))

# # Convert Pillow images to NumPy arrays
# average_image = np.array(average)
# lightness_image = np.array(lightness)
# luminance_image = np.array(luminance)

# Display the original and processed images using OpenCV
cv2.imshow('Origin image', image_cv2)
cv2.imshow('Average image', average)
# cv2.imshow('Lightness image', )
cv2.imshow('Luminance image', luminace)

# Wait for a key press and close the OpenCV windows
cv2.waitKey(0)
cv2.destroyAllWindows()
