import cv2 
import numpy as np 
from PIL import Image

# Specify the file path
file_path = r"C:\Data\Machine Vision\lena_color.png"

# Read the image using Pillow
image_pil = Image.open(file_path)

# Create a new image with properties similar to image_pil
binary_im = Image.new(mode=image_pil.mode, size=image_pil.size)

# Get the width and height of the image
width, height = image_pil.size

# Threshold value
threshold = 153

# Loop through each pixel in the image
for x in range(width):
    for y in range(height):
        # Get the RGB values of the pixel
        R, G, B = image_pil.getpixel((x, y))

        # Luminance method
        gray_lumi = np.uint8(0.2126 * R + 0.7152 * G + 0.0722 * B)
        
        # Apply thresholding to convert to binary
        if gray_lumi > threshold:
            binary = 255
        else:  
            binary = 0 
        
        # Set the pixel value in the binary image
        binary_im.putpixel((x, y), (binary, binary, binary))

# Convert the Pillow image to a NumPy array
binary_image = np.array(binary_im)

# Display the processed image using OpenCV
cv2.imshow('Binary Image', binary_image)

# Wait for a key press and close the OpenCV windows
cv2.waitKey(0)
cv2.destroyAllWindows()
