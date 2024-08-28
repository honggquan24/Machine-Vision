from pickletools import uint8
import numpy as np 
import cv2 as cv

def if_else(src, threshold):
    return np.where(src < threshold, 0, src)

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

def AverageBlurBGR(src, kernelsSize, padding_mode, stride):
  kernel_average = np.ones((kernelsSize, kernelsSize))
  B = np.array(src[:, :, 0])
  G = np.array(src[:, :, 1])
  R = np.array(src[:, :, 2])
  
  B_blured = conv2D(src= B,kernels= kernel_average, padding= padding_mode, strides= stride) / kernelsSize**2
  G_blured = conv2D(src= G,kernels= kernel_average, padding= padding_mode, strides= stride) / kernelsSize**2
  R_blured = conv2D(src= R,kernels= kernel_average, padding= padding_mode, strides= stride) / kernelsSize**2
  

  BGR_blured = np.stack((B_blured, G_blured, R_blured), axis=-1)
  
  return BGR_blured
  
def GaussianBlurBGR(src, kernelsSize, padding_mode, stride):
  kernels = {
     3 : (np.array([[1, 2, 1],
                    [2, 4, 2],
                    [1, 2, 1]])), 
     4 : (np.array([[0, 1, 0],
                    [1, -4, 1],
                    [0, 1, 0]])),                
     5 : (np.array([[1, 4, 7, 4, 1],
                    [4, 16, 26, 16, 4],
                    [7, 26, 41, 26, 7],
                    [4, 16, 26, 16, 4],
                    [1, 4, 7, 4, 1]])) }
  B = np.array(src[:, :, 0])
  G = np.array(src[:, :, 1])
  R = np.array(src[:, :, 2])
  
  B_blured = conv2D(src= B,kernels= kernels.get(kernelsSize), padding= padding_mode, strides= stride) / (128.5*kernelsSize - 369.5)
  G_blured = conv2D(src= G,kernels= kernels.get(kernelsSize), padding= padding_mode, strides= stride) / (128.5*kernelsSize - 369.5)
  R_blured = conv2D(src= R,kernels= kernels.get(kernelsSize), padding= padding_mode, strides= stride) / (128.5*kernelsSize - 369.5)
  
  BGR_blured = np.stack((B_blured, G_blured, R_blured), axis=-1)
  
  return BGR_blured

def ImageSharp(src, c_coefficient, threshold, kernels_numbers, padding_mode, stride):
  kernels = {
  1 : (np.array([[0, 1, 0],
                 [1, -4, 1],
                 [0, 1, 0]])), 
  2 : -(np.array([[0, 1, 0],
                 [1, -4, 1],
                 [0, 1, 0]])), 
  3 : (np.array([[1, 1, 1],
                 [1, -8, 1],
                 [1, 1, 1]])), 
  4 : -(np.array([[1, 1, 1],
                 [1, -8, 1],
                 [1, 1, 1]])) }

  B = (src[:, :, 0])
  G = (src[:, :, 1])
  R = (src[:, :, 2])
  
  B_sharp = c_coefficient * conv2D(B,kernels= kernels.get(kernels_numbers),
                                        padding= padding_mode, strides= stride)
  G_sharp = c_coefficient * conv2D(G,kernels= kernels.get(kernels_numbers),
                                        padding= padding_mode, strides= stride)
  R_sharp = c_coefficient * conv2D(R,kernels= kernels.get(kernels_numbers),
                                        padding= padding_mode, strides= stride)
  
  B_sharp = np.abs(B_sharp + B)
  G_sharp = np.abs(G_sharp + G)
  R_sharp = np.abs(R_sharp + R)
  
  BGR_sharp = np.stack((B_sharp, G_sharp, R_sharp), axis=-1)
  
  return BGR_sharp


img = cv.imread('lena_color.png')

average_blur = AverageBlurBGR(img, 9, 'valid', 1).astype((np.uint8))
gaussian_blur = GaussianBlurBGR(img, 9, 'valid', 1).astype((np.uint8))

cv.imshow('img', img)
cv.imshow('average_blur', average_blur)
cv.imshow('gaussian_blur', gaussian_blur)


cv.waitKey(0)
cv.destroyAllWindows()




