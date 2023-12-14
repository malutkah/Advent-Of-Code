package Helper

import (
	"bufio"
	"log"
	"os"
	"strconv"
	"unicode/utf8"
)

func SliceContains(elems []string, v string) bool {
	for _, s := range elems {
		if v == s {
			return true
		}
	}
	return false
}

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

/*
StoI receives a string and returns it as an integer
*/
func StoI(s string) int {
	i, _ := strconv.Atoi(s)
	return i
}

/*
ItoS receives a integer and returns it as an string
*/
func ItoS(n int) string {
	return strconv.Itoa(n)
}

func RtoS(r rune) string {
	return string(r)
}

func BtoS(b byte) string {
	return string(b)
}

func Uint8ToS(u uint8) string {
	return string(u)
}

func TrimFirstRune(s string) string {
	_, i := utf8.DecodeRuneInString(s)
	return s[i:]
}

func Trim(s string, fromIndex int) string {
	// _, i := utf8.DecodeRuneInString(s)
	return s[fromIndex:]
}

/*
MinMax returns the min and max value of a given slice of type int
*/
func MinMax(slice []int) (int, int) {
	var max int = slice[0]
	var min int = slice[0]
	for _, value := range slice {
		if max < value {
			max = value
		}
		if min > value {
			min = value
		}
	}
	return min, max
}
