"""
usefull snippets:
    - map(int, input().split())
    - map(int, sys.stdin.readline().split()))
    - int(input())
    - int(sys.stdin.readline().strip())

    - sys.stdout.write()
    - sys.stdout.write(" ".join(map(str, c) # writes c - collection of ints
"""
import collections
import sys


def get_ints():
    return map(int, sys.stdin.readline().strip().split())


def main():
    sys.stdout.write(" ".join(map(str, get_ints())))


if __name__ == "__main__":
    main()
