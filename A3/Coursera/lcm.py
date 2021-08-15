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
def lcm_naive(a, b):
    t=gcd_naive(a,b)
    return int(a*b/t)

toks=input().split()
a=int(toks[0])
b=int(toks[1])
print(lcm_naive(a, b))

