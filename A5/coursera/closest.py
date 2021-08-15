import math
#not finished
def minimum_distance(x, y):
    #write your code here
    return 10 ** 18









    n=int(input())
    points=[]
    for i in range(0,n):
        st=input().split()
        x = int(st[0])
        y = int(st[1])
        points.append((x,y))
    print("{0:.9f}".format(minimum_distance(x, y)))
