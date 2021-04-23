// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

if ('clipboard' in navigator) {
    let canWrite = false;
    navigator.permissions.query({ name: 'clipboard-write' }).then((perms) => {
        canWrite = perms.state;

        if (canWrite === "granted") {
            $("#copyToClipboard").on('click', () => { navigator.clipboard.writeText(window.document.getElementById('dueTitle').innerHTML); })
        } else if (canWrite === "prompt") {
            $("#copyToClipboard").on('click', () => { $("#clipboardPerms").show(); })
        } else {
            return;
        }

        $("#copyToClipboard").removeAttr('hidden');
    })
}