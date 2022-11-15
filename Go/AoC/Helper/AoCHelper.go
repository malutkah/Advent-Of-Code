package Helper

import (
	"bufio"
	"log"
	"os"
	"strconv"
)

func GetInput(year string, day string, file string) []string {
	var path = year + "/" + day + "/" + file + ".txt"
	f, err := os.Open(path)
	if err != nil {
		log.Fatal(err)
	}

	defer f.Close()

	scanner := bufio.NewScanner(f)

	var inputs []string

	for scanner.Scan() {
		inputs = append(inputs, scanner.Text())
	}

	return inputs
}

func StoI(s string) int {
	i, _ := strconv.Atoi(s)
	return i
}

func ItoS(n int) string {
	return strconv.Itoa(n)
}
