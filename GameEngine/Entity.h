#ifndef _ENTITY_H
#define _ENTITY_H

#include <string>

struct Entity
{
	friend class EntityManager;

public:

	//*******
	// Data *
	//*******

	// >>> Components go here <<<

	//************
	// Functions *
	//************

	std::string	getTag() const;

	int			getID() const;

	bool		isActive() const;

	void		destroy();

	//*******
	// Test *
	//*******

	static void	test();
	// Sample test to ensure Entity objects are created as intended.

private:

	//*******
	// Data *
	//*******

	std::string	TAG;
	int			ID;
	bool		active;

	//***************
	// Constructors *
	//***************

	Entity(const std::string& tag, const int& id);
};

#endif