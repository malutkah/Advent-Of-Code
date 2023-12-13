package day5

import (
	aoc "AoC/Helper"
	"fmt"
	"strings"
)

type stack struct {
	items []string
}

func (s *stack) Push(itm string) {
	s.items = append(s.items, itm)
	return
}

func (s *stack) Pop() (itm string) {
	itm = s.items[len(s.items)-1]
	s.items = s.items[:len(s.items)-1]
	return
}

func Solve() {
	var inputs = aoc.GetInput("2022", "day5", "test")
	var moves []string
	stacks := make([]stack, 3)

	for _, i := range inputs {
		if strings.HasPrefix(i, "move") {
			moves = append(moves, i)
		}
	}

	moveCreates(moves, stacks)
	fmt.Println(stacks)
}

func moveCreates(moves []string, stacks []stack) {

	for _, move := range moves {
		var amount, moveFrom, moveTo int
		_, _ = fmt.Sscanf(move, "move %d from %d to %d", &amount, &moveFrom, &moveTo)

		for m := 0; m < amount; m++ {
			// move crates around
			stacks[moveTo-1].Push(stacks[moveFrom-1].Pop())
		}
	}
}
