/*
Copyright © 2024 malutkah <alan.tressin@outlook.com>
*/
package main

import (
	"AoC/2024/day2"
	"AoC/cmd"
	"os"
)

func main() {
	os.Setenv("SOLVE_DAY1", "false")
	cmd.Execute()

	if shouldSolve() {
		day2.Solve()
	}
}

func shouldSolve() bool {
	return os.Getenv("SOLVE_DAY1") == "true"
}
