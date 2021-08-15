import random

def partition3(a, l, r):
    x = a[l]
    start=l+1
    end=l
    for i in range(l + 1, r + 1):
        if a[i] <= x:
            end += 1
            a[i], a[end] = a[end], a[i]
            
            if a[end] < x:
                a[start], a[end] = a[end], a[start]
                start += 1
                
    a[l], a[start-1] = a[start-1], a[l]

    return [start, end]






def randomized_quick_sort(a, l, r):
    if l >= r:
        return
    k = random.randint(l, r)
    a[l], a[k] = a[k], a[l]
    #use partition3
    [m1, m2] = partition3(a, l, r)
    randomized_quick_sort(a, l, m1 - 1);
    randomized_quick_sort(a, m2 + 1, r);


n=int(input())
line=input().split()
a=[]
for i in line:
    a.append(int(i))
randomized_quick_sort(a, 0, n - 1)
for x in a:
    print(x, end=' ')
