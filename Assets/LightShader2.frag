#version 120

uniform vec2 PlayerScreenPos;
uniform float coneScale;

void main()
{
  float dist = distance(gl_TexCoord[0].xy / coneScale, PlayerScreenPos / coneScale);
  vec4 pixel = vec4(0,0,0,dist);
  gl_FragColor = gl_Color * pixel;
}


#version 120

uniform vec2 PlayerScreenPos;
uniform float coneScale;
uniform float time;  // New uniform for time

void main()
{
    float dist = distance(gl_TexCoord[0].xy / coneScale, PlayerScreenPos / coneScale);
    
    // Discard fragments outside the coneScale range
    if (dist > 1.0)
        discard;

    vec4 pixel = vec4(0, 0, 0, dist);

    // Add flicker effect based on time
    float flickerAmount = abs(sin(time * 2.0));  // Adjust the factor to control the flicker speed
    pixel.a *= flickerAmount;

    gl_FragColor = gl_Color * pixel;
}
