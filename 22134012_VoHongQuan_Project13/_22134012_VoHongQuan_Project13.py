# #%%
# import cv2
# from PIL import Image 
# import numpy as np

# pic_file = r"C:\Data\Machine Vision\lena_color.png"
# img = cv2.imread(pic_file, cv2.IMREAD_COLOR)
# imgPIL = Image.open(pic_file)
# imgOk = Image.new(imgPIL.mode, imgPIL.size)

# w = imgPIL.size[0]
# h = imgPIL.size[1]

# X1, X2, Y1, Y2 = 80, 150, 400, 500
# threshold = 45
# Gs, Rs, Bs = 0, 0, 0 

# for x in range(X1,X2):
#     for y in range(Y1,Y2):
#         R,G,B = imgPIL.getpixel((x,y))
#         Rs += R
#         Gs += G
#         Bs += B

# S = (X2-X1+1)*(Y2-Y1+1)
# Rs = Rs/S
# Gs = Gs/S
# Bs = Bs/S

# for x in range(w):
#     for y in range(h):
#         R1,G1,B1 = imgPIL.getpixel((x,y))
#         D = np.sqrt((R1-Rs)**2+(G1-Gs))
#         if D < threshold:
#             imgOk.putpixel((x,y),(255,255,255))
#         else:
#             imgOk.putpixel((x,y),(B1,G1,R1))

# imgzz = np.array(imgOk)
# #cv2.imshow('Original Image',pic_file)
# cv2.imshow('Hinh phan loai mau X1=80 X2=150 Y1=400 Y2=500',imgzz)
# cv2.waitKey(0)
# cv2.destroyAllWindows()            


# %%
import cv2
import numpy as np
from PIL import Image
def color_segmentation(Image_path, X1, X2, Y1, Y2, threshold):
    imgPIL = Image.open(Image_path)
    imgOk = Image.new(imgPIL.mode, imgPIL.size)
    Rs, Gs, Bs = np.mean(np.array(imgPIL.crop((X1, Y1, X2, Y2))), axis=(0,1))

    for x in range(imgPIL.size[0]):
        for y in range(imgPIL.size[1]):
            R1, G1, B1 = imgPIL.getpixel((x, y))
            D = np.sqrt((R1 - Rs)**2 + (G1 - Gs)**2 + (B1 - Bs)**2)
            imgOk.putpixel((x, y), (255, 255, 255) if D < threshold else (B1, G1, R1))

    return np.array(imgOk)

pic_file = r"C:\Data\Machine Vision\lena_color.png"
X1, X2, Y1, Y2 = 80, 150, 400, 500
threshold = 45

segmented_image = color_segmentation(pic_file, X1, X2, Y1, Y2, threshold)

cv2.imshow('Segmented Image', segmented_image)
cv2.waitKey(0)
cv2.destroyAllWindows()



# %%

