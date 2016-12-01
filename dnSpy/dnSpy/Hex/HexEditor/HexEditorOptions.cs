﻿/*
    Copyright (C) 2014-2016 de4dot@gmail.com

    This file is part of dnSpy

    dnSpy is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    dnSpy is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with dnSpy.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using dnSpy.Contracts.Settings.HexEditor;
using dnSpy.Contracts.Settings.HexGroups;
using dnSpy.Hex.Settings;

namespace dnSpy.Hex.HexEditor {
	sealed class HexEditorOptions : CommonEditorOptions {
		public Guid Guid { get; }
		public string Name { get; }

		HexEditorOptions(HexViewOptionsGroup group, string tag, Guid guid, string name)
			: base(group, tag) {
			Guid = guid;
			Name = name;
		}

		public static HexEditorOptions TryCreate(HexViewOptionsGroup group, IHexEditorOptionsDefinitionMetadata md) {
			if (group == null)
				throw new ArgumentNullException(nameof(group));
			if (md == null)
				throw new ArgumentNullException(nameof(md));

			if (md.Tag == null)
				return null;
			var tag = md.Tag;
			if (tag == null)
				return null;

			if (md.Guid == null)
				return null;
			Guid guid;
			if (!Guid.TryParse(md.Guid, out guid))
				return null;

			if (md.Name == null)
				return null;

			return new HexEditorOptions(group, tag, guid, md.Name);
		}
	}
}
