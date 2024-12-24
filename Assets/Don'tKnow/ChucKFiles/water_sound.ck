// Generate a dripping water sound
SndBuf drip => dac;
"water_drip.wav" => drip.read; // Replace with your water sound file
0.5 => drip.gain; // Set volume

// Loop the drip sound
while (true)
{
    0 => drip.pos; // Reset the position
    drip.play();   // Play the sound
    1::second => now; // Wait for 1 second
}
