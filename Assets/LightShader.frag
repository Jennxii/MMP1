#version 120

uniform vec2 PlayerScreenPos;
uniform float coneScale;
uniform float time;
const float flickerThreshold = 0.1; // Adjust the threshold value as needed
const float flickerRange = 0.9; // Adjust the range value as needed

void main()
{
    // Calculate the distance from the player position to the current fragment position
    float dist = distance(gl_TexCoord[0].xy, PlayerScreenPos);

    if (dist > coneScale)
    {
        gl_FragColor = vec4(0.0, 0.0, 0.0, 1.0);
    }
    else
    {
        // Calculate the distance from the fragment position to the center of the cone
        float centerDist = abs(dist - coneScale);

        // Calculate the flicker amount based on the distance from the cone edge to halfway towards the center
        float flickerAmount = abs(cos(time * 10.0) * sin(time * 12.0) * (1.0 - centerDist / coneScale));

        // Apply the threshold and range
        flickerAmount = max(flickerAmount - flickerThreshold, 0.0) / flickerRange;

        // Soften the flicker effect
        flickerAmount = smoothstep(0.1, 0.9, flickerAmount);

        gl_FragColor = vec4(0.0, 0.0, 0.0, flickerAmount);
    }
}
