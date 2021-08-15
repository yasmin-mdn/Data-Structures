def max_pairwise_product(numbers):
    n=len(numbers)
    Max1=Max2=0
    for i in range(0,n):
            if(numbers[i]>Max1):
                Max2=Max1
                Max1=numbers[i]
            elif(numbers[i]>Max2):
                Max2=numbers[i]

    
    return Max1*Max2

if __name__ == '__main__':
    input_n = int(input())
    input_numbers = [int(x) for x in input().split()]
    print(max_pairwise_product(input_numbers))




