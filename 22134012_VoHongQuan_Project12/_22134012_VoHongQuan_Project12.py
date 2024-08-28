from pickletools import uint8
import numpy as np 
import cv2 as cv

def conv2D(src, kernels, padding, strides):
  src = src
  kernels = kernels

  inputSize = src.shape
  kernelSize = kernels.shape

  if padding == 'valid':
    paddingValue = 0

  if padding == 'same':
    paddingValue = (kernelSize[0]-1)//2

  outputSize = (inputSize[0] - kernelSize[0] + 2*paddingValue) // strides + 1
  output = np.zeros((outputSize, outputSize))
  src_zeros = np.zeros((inputSize[0] + 2*paddingValue, inputSize[1] + 2*paddingValue))
  src_zeros[paddingValue: inputSize[0] + paddingValue, paddingValue: inputSize[0] + paddingValue,] = src

  kernelsize_half = (kernelSize[0]-1)//2

  for i in range(kernelsize_half, src_zeros.shape[0] - kernelsize_half, strides):
    for j in range(kernelsize_half, src_zeros.shape[1] - kernelsize_half, strides):
      valueSrc = src_zeros[i - kernelsize_half: i + kernelsize_half + 1, j - kernelsize_half: j + kernelsize_half + 1]
      if ((valueSrc.shape[0]) < kernelSize[0]) or ((valueSrc.shape[1]) < kernelSize[1]): 
        break
      output[(i-kernelsize_half)//strides, (j-kernelsize_half)//strides] = np.sum(valueSrc * kernels)
  return output

def ImageSharpBGR(src, c_coefficient, kernels_numbers, padding_mode, stride):
    kernels = {
    1: (np.array([[0, 1, 0],
                  [1, -4, 1],
                  [0, 1, 0]])), 
    2: -(np.array([[0, 1, 0],
                   [1, -4, 1],
                   [0, 1, 0]])), 
    3: (np.array([[1, 1, 1],
                  [1, -8, 1],
                  [1, 1, 1]])), 
    4: -(np.array([[1, 1, 1],
                   [1, -8, 1],
                   [1, 1, 1]]))
    }

    B = src[:, :, 0]
    G = src[:, :, 1]
    R = src[:, :, 2]

    B_sharp = c_coefficient * conv2D(B, kernels=kernels.get(kernels_numbers), padding=padding_mode, strides=stride)
    G_sharp = c_coefficient * conv2D(G, kernels=kernels.get(kernels_numbers), padding=padding_mode, strides=stride)
    R_sharp = c_coefficient * conv2D(R, kernels=kernels.get(kernels_numbers), padding=padding_mode, strides=stride)

    # Clip and convert to uint8

    #B_sharp = np.clip(B + B_sharp, 0, 255).astype(np.uint8)
    #G_sharp = np.clip(G + G_sharp, 0, 255).astype(np.uint8)
    #R_sharp = np.clip(R + R_sharp, 0, 255).astype(np.uint8)

    BGR_sharp = np.stack((B_sharp, G_sharp, R_sharp), axis=-1)

    return BGR_sharp


img = cv.imread("C:\Data\Machine Vision\lena_color.png")
imagesharp = ImageSharpBGR(img, 1, 2, 'same', 1)

cv.imshow('img', img)
cv.imshow('ImageSharp', imagesharp)

cv.waitKey(0)
cv.destroyAllWindows()
