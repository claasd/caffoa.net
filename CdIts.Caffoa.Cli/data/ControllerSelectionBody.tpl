        switch ({SWITCHON})
        {{
        {CASES}
        default: return BadRequest("Discriminator not found");
        }}
