import numpy as np
import pandas as pd
import scipy.io
import matplotlib.pyplot as plt
from mpl_toolkits.mplot3d import Axes3D
import open3d as o3d
import  cv2 as cv

# Read file csv
camera_txt = pd.read_csv("C:/Users/ADMIN/Downloads/camera.txt")

# Read depth file
depth_example = scipy.io.loadmat("C:/Users/ADMIN/Downloads/depth example.mat")

# Distance
distance = np.array(depth_example['depth'])

Sx = 32 / 1024
fx = fy = 24 / Sx

# Size
height, width = distance.shape

# Matrix
matrix = np.zeros((height * width, 3))

# Calculate
for x in range(height):
    for y in range(width):
        Cx = width / 2
        Cy = height / 2
        input_matrix = [[x],
                        [y],
                        [1]]
        intermediate_matrix = [[fx, 0, Cx],
                               [0, fy, Cy],
                               [0, 0, 1]]
        output_matrix = np.linalg.solve(intermediate_matrix, input_matrix)
        Z = distance[x, y] / np.sqrt(1 + ((x - Cx) / fx) ** 2 + ((y - Cy) / fy) ** 2)

        matrix[y + x * width, :] = Z * output_matrix.reshape(1, 3)

x, y, z = zip(*matrix)

# Create an Open3D point cloud
# point_cloud = o3d.geometry.PointCloud()
# point_cloud.points = o3d.utility.Vector3dVector(np.column_stack((x, y, z)))


# Visualize the Open3D point cloud
# o3d.visualization.draw_geometries([point_cloud])

cap = cv.VideoCapture('http://192.168.13.57:8080/video')

while True:
    ret, frame = cap.read()
    resize = np.resize(frame, (1080, 720))
    cv.imshow('Camera', frame)
    
    key  = cv.waitKey(1)
    if (key == ord('q')): 
        break

cap.release()
cv.destroyAllWindows()
    