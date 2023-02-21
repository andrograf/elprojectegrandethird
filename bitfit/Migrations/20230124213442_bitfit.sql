
IF NOT EXISTS ( SELECT 1 FROM Recipes WHERE Name = 'Champagne Mushroom Risotto')
BEGIN
INSERT INTO Recipes (Name, Title, Ingredients, Servings, Instructions) VALUES
    ('Champagne Mushroom Risotto',
    'Champagne Mushroom Risotto',
     '3 tb Butter or margarine|1 c Converted rice|2/3 c Onion; chopped|1 3/4 c Water|3/4 c Champagne or dry white wine|1 cn Cream of mushroom soup|1/4 ts Fresh ground pepper|1/8 ts Ground nutmeg|1/8 ts Ground red pepper(optional)|1 c Red bell pepper; julienne|Fresh parsley; finely chop|Parmesan cheese (optional)',
     '6 Servings',
     'Melt butter in medium saucepan. Add rice and onion. Cook over medium heat, stirring frequently, 3-4 minutes or until onion is tender. Add water and champagne. Bring to a boil. Reduce heat, cover and simmer 20 minutes. Stir in cream of mushroom soup, pepper, nutmeg, and, if desired, ground red pepper. Cook and stir 5 minutes, or until creamy and heated through. Stir in red bell pepper and parsley. Sprinkle with cheese, if desired.'),
    ('Elegant Chicken in Sour Cream',
    'Elegant Chicken in Sour Cream',
     '** Package Together **|2 oz Freeze-Dried Chicken, Or|4 oz Chicken-Flavored T.V.P.|4 Chicken Bouillon Cube, Or|1/4 c Chicken Bouillon Granules|8 oz Pasta, Enriched|1 ts Dill Weed|** Package Sepatately **|1 Env Cream Of Onion Soup Mix|To make 2 1/2 cups|8 oz Sour Cream Mix|1/2 c Sliced Almonds|2 oz Freeze-Dried Peas|8 c Water',
     '4 Servings',
      '1. Bring 7 cups of water to boiling, add pasta-chicken package, and simmer for 10 minutes, stirring occasionally. Add peas, at the end, for the amount of time recommended on their package. 2. Mix soup mix with 1/2 cup of water. Pour into pot while stirring, and simmer 5-10 minutes more, or until pasta and chicken are tender. 3. Reconstitute sour cream mix with cold water, stir into the pot. Serve sprinkled with almonds on top. Makes about 8 cups.'),
    ('Berry Tiramisu',
    'Berry Tiramisu',
     '1 c Fresh raspberries|1 c Fresh blueberries|1 c Fresh blackberries|1 c Sliced strawberries|1 c Sugar|Juice of one lemon|2 pt Heavy cream|8 oz Mascarpone cheese|1/2 c Powdered sugar|1 Prepared sponge cake - (9\" by 9\" by 2\"); sliced into 3 layers|1 c Chambord liqueur|1/2 c Raspberry coulis|Fresh mint sprigs|Powdered sugar in shaker',
      '12 servings',
       'In a mixing bowl, combine all the berries with the sugar and lemon juice. With a fork, lightly mash 1/4 of the berries against the side of the bowl. Allow the berries to sit for 1 hour. Using an electric mixer, whip the cream until stiff peaks form. In a mixing bowl, fold half of the whipped cream into the Mascarpone cheese, along with the powdered sugar. Blend until the cream is fully incorporated. To assemble, lay one layer of the sponge cake on the bottom of the pan. Brush the layer with the Chambord. Spread 1/3 of the cheese mixture over the sponge cake. Repeat the procedure until all of the cake and cheese mixture are used. Spread the reserved whipped cream over the top of the cake. Allow the cake to set, about 1 hour. Place a slice of the tirmisu on the plate. Garnish with raspberry coulis, fresh mint and powdered sugar. This recipe yields 12 servings.'),
    ('Gyros',
    'Gyros',
     '1/4 c Water|1 md Onion, finely chopped|3 tb Chopped parsley|2 ts Oregano|4 lg Cloves garlic, minced|2 ts Pepper|3 ts Salt|2 ts Ground cumin|1 ts Ground fenugreek|8 Individual pita breads|1 lg Onion, sliced into thin rings|1 lg Tomato, coarsely chopped|1 Clove garlic, minced|1/2 ts Mustard (dijon)|1 tb Red wine vinegar|3 tb Olive oil|1 c Plain yogurt',
     '1 Servings',
      'Combine ground lamb, water, onion, parsley, oregano, garlic, pepper, salt, cumin and fenugreek and mix thoroughly. Shape into loaf and wrap tightly in plastic film to compress the mixture. Refrigerate for 2 hours. To cook in the oven: Preheat oven to 350F. Unwrap meat mixture and place on a cookie sheet or shallow baking dish and bake 1 to 1 1/2 hours. Remove from oven, drain excess fat and let stand 15 minutes before carving. Use a very sharp knife and cut in thin slices. To cook on a rotisserie: Push the metal skewer through the center of the meat (lengthwise) and place attachment in oven according to its directions. Cook at 350F, carving the cooked and crispy outside slices as needed. To cook on the grill: Place the meat on a hot grill. Turn and continue to cook until brown on all sides. Slice thin srips from the browned loaf as it cooks, exposing unbrowned surface to be browned as you carve thin slices from the other side. Continue turning the loaf, browning the surface exposed to the fire while you carve from the side facing away from the coals. When the loaf is too small to carve on the grill, brown on all sides and cut into slices.')
END

IF NOT EXISTS ( SELECT 1 FROM Foods WHERE Name = 'potato')
BEGIN
INSERT INTO Foods (Name,Sugar,Fiber, ServingSize,Sodium,Potassium,FatSaturated,FatTotal,Calories,Cholesterol,Protein,Carbohydrates) VALUES
    ('potato', 1.2, 2.2, 100,10,70,0,0.1,92.7,2.5,0.7,21),
    ('pear', 9.8,3.1,100,1,11,0,0.1,56.7,0,0.4,14.9),
    ('oat', 1,10.3,100,6,416,1.1,6.4,368.3,0,13.2,67),
    ('rice', 0.1,0.4,100,1,42,0.1,0.3,127.4,0,2.7,28.4)
END

IF NOT EXISTS ( SELECT 1 FROM Users WHERE Name = 'Frank')
BEGIN
 INSERT INTO Users (Name, Email, WeightInKg, HeightInCm, BMI) VALUES
--     ('tomi', 'hajas@hajas.com', 94, 187, 0),
--     ('patri', 'patri@patri.com', 53, 167,0),
--     ('gergo', 'gergo@gergo.com', 80, 175,0),
--     ('robi', 'robi@robi.com', 85, 185,0),
     ('Frank', 'frank@frank.com', 103, 192,0)
END