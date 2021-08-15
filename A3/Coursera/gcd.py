# Uses python3
def gcd_naive(a, b):
    if (b>a):
        tmp=b
        b=a
        a=tmp
    if(b==0):
        return a
    if(b==1 or a==1):
        return 1
    r=a % b
    return gcd_naive(b,r)

toks=input().split()
a=int(toks[0])
b=int(toks[1])
print(gcd_naive(a, b))
