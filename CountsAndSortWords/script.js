function countWordFrequency(text) {
  // Convert to lowercase and remove punctuation
  const cleanedText = text.toLowerCase().replace(/[^\w\s]/g, "");

  // Split into words
  const words = cleanedText.split(/\s+/);

  // Count occurrences
  const frequency = {};

  for (let word of words) {
    if (word === "") continue;
    frequency[word] = (frequency[word] || 0) + 1;
  }

  return frequency;
}

function processText() {
  const text = document.getElementById("inputText").value;

  const frequencies = countWordFrequency(text);

  // Sort by frequency (descending)
  const sorted = Object.entries(frequencies)
    .sort((a, b) => b[1] - a[1]);

  const output = document.getElementById("output");
  output.innerHTML = "";

  sorted.forEach(([word, count]) => {
    const li = document.createElement("li");
    li.textContent = word + ": " + count;
    output.appendChild(li);
  });
}