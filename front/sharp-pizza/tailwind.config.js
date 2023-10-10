/** @type {import('tailwindcss').Config} */
export default {
  content: ['./index.html', './src/**/*.{js,ts,jsx,tsx}'],
  theme: {
    screens: {
      // Small devices such as mobile phones
      sm: '480px',
      // => @media (min-width: 640px) { ... }

      // Larger devices like tablets
      md: '768px',
      // => @media (min-width: 768px) { ... }

      // Medium size laptops and screens
      lg: '1024px',
      // => @media (min-width: 1024px) { ... }

      // Pantallas más grandes como las de escritorio
      xl: '1280px',
      // => @media (min-width: 1280px) { ... }

      // Extra large screens or high resolution screens
      '2xl': '1536px',
      // => @media (min-width: 1536px) { ... }
    },
    extend: {},
  },
  plugins: [require('daisyui')],
  daisyui: {
    themes: false, // true: all themes | false: only light + dark | array: specific themes like this ["light", "dark", "cupcake"]
    darkTheme: 'dark', // name of one of the included themes for dark mode
    base: true, // applies background color and foreground color for root element by default
    styled: true, // include daisyUI colors and design decisions for all components
    utils: true, // adds responsive and modifier utility classes
    rtl: false, // rotate style direction from left-to-right to right-to-left. You also need to add dir="rtl" to your html tag and install `tailwindcss-flip` plugin for Tailwind CSS.
    prefix: '', // prefix for daisyUI classnames (components, modifiers and responsive class names. Not colors)
    logs: true, // Shows info about daisyUI version and used config in the console when building your CSS
  },
};
