// Exploring os module
// const os = require('os');

// console.log('Operating System: ', os.platform());
// console.log('Hostname: ', os.hostname());
// console.log('Home Directory: ', os.homedir());
// console.log('Number of CPUs: ', os.cpus().length);
// console.log('Free Memory: ', os.freemem() / (1024*1024) + ' MB');

// File Organizer
const fs = require('fs').promises;
const path = require('path');

async function organizeFolder(folderName) {
    try {
        // target directory in the current folder itself
        const targetDir = path.join(__dirname, folderName);

        // Reading files in target drectory
        const files = await fs.readdir(targetDir);
        for (const file of files){

            // Full path for eah file
            const oldPath = path.join(targetDir, file);
            const stats = await fs.lstat(oldPath);
            //console.log('old path status', file,stats);
            // if its a file ignore and continue
            if (stats.isDirectory()){
                console.log(`${file} is a Directory`);
                continue;
            }

            // extract the extension
            const ext = path.extname(file).slice(1) || 'others';
            // Create a folder based on extension
            const categoryDir = path.join(targetDir, ext);
            await fs.mkdir(categoryDir, {recursive: true});

            // create a new path and move (rename)
            const newPath = path.join(categoryDir, file);
            await fs.rename(oldPath, newPath);

            console.log(`Successfully organized: ${file}`);
        }

        console.log('Done, organizing the files');
    } catch (error) {
        console.error('Error organizing files: ', error.message);
    }
    
}


organizeFolder('my_downloads');