const endpoint = 'http://localhost:5184/favoritewords';

class ApiWordService {


    async add(newWord) {
        const headers = {
            'Content-Type': 'application/json',
        }
        await fetch(endpoint, { body: JSON.stringify(newWord), method: 'POST', headers });
    }

    async get() {
        const response = await fetch(endpoint);
        return await response.json();
    }

    async remove(toRemove) {
        await fetch(`${endpoint}/${toRemove}`, { method: 'DELETE' });
    }
}

const wordService = new ApiWordService();

window.removeWord = async (word) => {
    await wordService.remove(word);
    refresh();
}

window.addWord = async () => {
    const newWord = document.querySelector('#a-new-word').value;
    if (!!newWord) {
        await wordService.add(newWord);
        refresh();
    }
}


const renderWord =
    word => `   <div class="panel-block">
                    <div class="block">
                        <span class="tag is-light">
                            ${word}
                            <button class="delete is-small is-danger" onclick='removeWord("${word}")'></button>
                        </span>
                    </div>
                </div>`;


const renderPanel =
    (words) => `
            <div class="panel">
                <p class="panel-heading">
                    Favorite Words
                </p>

                <div class="panel-block">
                    <p class="control has-icons-left">
                        <button class="button is-left" onclick='addWord()'>
                            <span class="icon is-small">
                              <i class="fas fa-plus"></i>
                            </span>
                        </button>
                        <input id='a-new-word' class="input" type="text" placeholder="New word...">


                    </p>
                </div>

                ${words.map(renderWord).join('')}
     </div>
`;



const refresh = async () => {
    const words = await wordService.get();
    if (!!words) {
      document.querySelector('#a-panel').innerHTML = renderPanel(words);
    }
}

refresh();