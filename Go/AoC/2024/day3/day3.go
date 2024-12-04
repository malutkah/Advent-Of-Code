package day3

import (
	"fmt"
	"regexp"
	"strconv"
	"strings"

	aoc "AoC/Helper"
)

func mul(exp string) int {
	res := 0

	r, err := regexp.Compile("\\d{1,3}")
	if err != nil {
		fmt.Println("error compiling regex", err)
		return -1
	}
	foundNum := r.FindAllString(exp, -1)
	// fmt.Println(foundNum)

	if len(foundNum[1]) > 3 || len(foundNum[1]) > 3 {
		fmt.Println("number to big")
	} else {
		num1, _ := strconv.Atoi(foundNum[0])
		num2, _ := strconv.Atoi(foundNum[1])
		return num1 * num2
	}

	return res
}

// `[d][o][(][)].*?mul[(]\d{1,3},\d{1,3}[)]`gm
func Solved() {
	var inputs = aoc.GetInput("2024", "day3", "input")
	sum := 0

	for _, line := range inputs {
		r, err := regexp.Compile("mul[(]\\d{1,3},\\d{1,3}[)]")
		if err != nil {
			fmt.Println("error compiling regex", err)
			return
		}

		mulFuncsString := r.FindAllString(line, -1)
		for _, exp := range mulFuncsString {
			sum += mul(exp)
		}
	}
	fmt.Println(sum)
}

func canDoMultiply(matchIndices []int, doIndices [][]int, dontIndices [][]int) bool {
	if matchIndices[0] < dontIndices[0][0] {
		return true
	}

	// find most recent do
	lastDo := doIndices[len(doIndices)-1][0]
	for i := len(doIndices) - 1; i >= 0; i-- {
		if doIndices[i][0] < matchIndices[0] {
			lastDo = doIndices[i][0]
			break
		}
	}

	// find most recent dont
	lastDont := dontIndices[len(dontIndices)-1][0]
	for i := len(dontIndices) - 1; i >= 0; i-- {
		if dontIndices[i][0] < matchIndices[0] {
			lastDont = dontIndices[i][0]
			break
		}
	}

	return lastDo > lastDont && matchIndices[0] > lastDo
}

func Solve() {
	var inputs = aoc.GetInput("2024", "day3", "test")
	input := strings.Join(inputs, "\n")

	r := regexp.MustCompile("mul\\(([0-9]+),([0-9]+)\\)")
	foundMul := r.FindAllStringSubmatch(input, -1)
	fmt.Println(foundMul)
	matchesIndices := r.FindAllStringSubmatchIndex(input, -1)

	rDo := regexp.MustCompile("do\\(\\)")
	doIndices := rDo.FindAllStringIndex(input, -1)

	rDont := regexp.MustCompile("don't\\(\\)")
	dontIndices := rDont.FindAllStringIndex(input, -1)

	total := 0
	for i := 0; i < len(foundMul); i++ {
		if !canDoMultiply(matchesIndices[i], doIndices, dontIndices) {
			continue
		}

		num1, err := strconv.Atoi(foundMul[i][1])
		if err != nil {
			panic(err)
		}
		num2, err := strconv.Atoi(foundMul[i][2])
		if err != nil {
			panic(err)
		}
		total += num1 * num2
	}

	fmt.Println("Part 2 sum: ", total)
}
