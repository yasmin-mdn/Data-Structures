# Uses python3
import math

def binary_search(a, x):
    left, right = 0, len(a)-1
    while left<=right:
        # if right<left:
        #     return left-1
        mid=left+(right-left)//2
        if(x==a[mid]):
            return mid
        elif x<a[mid]:
            right=mid-1
        elif x>a[mid]:
            left=mid+1
        
    return -1





line1=input().split()
line2=input().split()
n = int(line1[0])
a = []
b=[]
for i in line1[1 : n + 1]:
    a.append(int(i))
k = int(line2[0])
for i in line2[1 : k + 1]:
    b.append(int(i))
for x in b:
    print(binary_search(a, x), end = ' ')
