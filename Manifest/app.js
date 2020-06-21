var io = require('socket.io').listen(8000);

console.log('Starting');

io.on('connection', function(socket) {
   console.log('A user connected');
   
   console.log('Sending');

   socket.send('emitter');

   socket.on('test', function () {
      console.log('Test run'); });

   socket.on('disconnect', function () {
      console.log('A user disconnected'); });

});