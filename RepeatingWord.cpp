#include <iostream>
#include <stdlib.h>
#include <string>
using namespace std;

int main() {
	system("chcp 1251");

	string sentence;
	cout << "Въведете символен низ: ";
	getline(cin, sentence);
	string word, lastWord, currentWord;
	int wordReps = 0, currentReps = 0;

	for (auto c : sentence) {
		if (ispunct(c) || c == ' ') {
			cout << currentWord << endl;
			if (lastWord.length() > 0) {
				currentWord == lastWord ? ++currentReps : currentReps = 1;
				currentReps > wordReps ? (word = currentWord, wordReps = currentReps) : 0;
				lastWord = currentWord;
				currentWord = "";
			}
			else {
				lastWord = currentWord, word = currentWord, currentWord = "";
				++wordReps, ++currentReps;
			}
		} else {
			// Words with uppercase letters may be the same as those before or after them!
			auto newChar = tolower(c);
			currentWord += newChar;
		}
	}

	if (wordReps > 1)
		cout << "Най-повтаряната дума е: " << word << ", " << wordReps << " пъти\n";
	else
		cout << "Няма повтарящи се думи.\n";

	return 0;
}
